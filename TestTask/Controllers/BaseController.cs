using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class BaseController<T> : ApiController
        where T : class
    {
        private DBContext db = new DBContext();

        // GET: api/Orders
        public IQueryable<T> GetEntity()
        {
            try
            {
                return db.Set<T>();
            }
            catch (Exception exception)
            {
                throw new Exception("The server does not respond. Check the connection to the server.", exception);
            }
        }

        // GET: api/Orders/5
        public async Task<IHttpActionResult> GetEntities(Guid id)
        {
            try
            {
                T entity = await db.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception exception)
            {
                throw new Exception("The server does not respond. Check the connection to the server.", exception);
            }
        }

        // POST: api/Orders
        public async Task<IHttpActionResult> PostEntities([FromBody]T[] urlEntity)
        {

            for (int i = 0; i < urlEntity.Length; i++)
            {
                if (!EntityExists(urlEntity[i]))
                {
                    db.Set<T>().Add(urlEntity[i]);
                }
                else
                {
                    return Content<string>(System.Net.HttpStatusCode.OK, "The object is already present in DB");
                }
            }

            try
            {
                await db.SaveChangesAsync();

            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }

            return Content<string>(System.Net.HttpStatusCode.OK, "The object has been added to DB");
        }

        // DELETE: api/Orders/5
        public async Task<IHttpActionResult> DeleteEntity(Guid id)
        {
            try
            {
                T entity = await db.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }

                db.Set<T>().Remove(entity);
                await db.SaveChangesAsync();

                return Content<string>(System.Net.HttpStatusCode.OK, "The object has been deleted from DB");
            }
            catch (Exception exception)
            { throw new Exception("Something went wrong...", exception); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntityExists(T urlEntity)
        {
            try
            {
                IEntity entity = urlEntity as IEntity;
                T entityExist = db.Set<T>().Find(entity.Id);
                return entityExist == null ? false : true;
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong...", exception);
            }
        }

    }
}