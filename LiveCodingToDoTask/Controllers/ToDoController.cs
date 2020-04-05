using LiveCodingToDoTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveCodingToDoTask.Controllers
{
    [Route("api/ToDo")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ToDo> GetAllToDo()
        {
            return _context.ToDo.ToList();
        }

        [Route("GetToDoForAWeek")]
        [HttpGet]
        public List<ToDo> GetToDoForAWeek()
        {
            //get first day of this week
            var weekStart = DateTimeExtensionHelpers.FirstDayOfWeek(DateTime.Now);
            //get end day of this week
            var weekEnd = DateTimeExtensionHelpers.LastDayOfWeek(weekStart);

            //get data ToDo for this week
            var getData = (from a in _context.ToDo
                           where a.expiredDate.Date >= weekStart && a.expiredDate.Date <= weekEnd
                           select a).ToList();

            return getData;
        }

        // GET: api/ToDo/5
        [HttpGet("{id}")]
        public ToDo GetTodoById(int id)
        {
            //get Todo by Id
            var toDo = _context.ToDo.Find(id);

            if (toDo == null)
            {
                return new ToDo();
            }

            return toDo;
        }

        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public ToDo PutToDoes(int id, [FromBody]ToDo toDoes)
        {
            //get data by Id for update
            var dataToUpdate = _context.ToDo.Find(id);

            //validation when data by Id doesn't exist
            if(dataToUpdate != null)
            {
                //process update
                dataToUpdate.title = toDoes.title == null ? dataToUpdate.title : toDoes.title;
                dataToUpdate.description = toDoes.description == null ? dataToUpdate.description : toDoes.description;
                dataToUpdate.expiredDate = toDoes.expiredDate == DateTime.MinValue ? dataToUpdate.expiredDate : toDoes.expiredDate;

                _context.ToDo.Update(dataToUpdate);
            }
            _context.SaveChanges();

            return dataToUpdate;
        }

        // PUT: api/ToDo/SetPercentComplete/3
        [Route("SetPercentComplete/{id}")]
        [HttpPut("{id}")]
        public ToDo SetPercentComplete(int id, [FromBody]ToDo toDoes)
        {
            // just update the percentage

            var dataToUpdate = _context.ToDo.Find(id);
            if (dataToUpdate != null)
            {
                dataToUpdate.percentage = toDoes.percentage;

                _context.ToDo.Update(dataToUpdate);
            }
            _context.SaveChanges();

            return dataToUpdate;
        }

        // POST: api/ToDo
        [HttpPost]
        public void PostToDoes([FromBody]ToDo toDoes)
        {
            //get all data ToDo
            _context.ToDo.Add(toDoes);
            _context.SaveChanges();
        }

        // POST: api/ToDo/MarkAsDone
        [Route("MarkAsDone")]
        [HttpPost]
        public void MarkAsDone()
        {
            // update the status to done when percentage is 100

            var getData = (from a in _context.ToDo
                           where a.percentage == 100
                           select a).ToList();

            foreach(var item in getData)
            {
                item.status = "Done";

                _context.ToDo.Update(item);
            }
            _context.SaveChanges();
        }

        // DELETE: api/ToDo/5
        [HttpDelete("{id}")]
        public void DeleteToDoes(int id)
        {
            //delete data by Id

            var toDo = _context.ToDo.Find(id);
            if (toDo != null)
            {
                _context.ToDo.Remove(toDo);
                _context.SaveChanges();
            }
        }
    }
}
