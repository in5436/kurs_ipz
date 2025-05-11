using System.Data;

namespace Sheduler.Controller {
    public interface IWriteController : IPageController {
        void Add(DataRow dr);

        void Edit(DataRow dr);

        void Delete(DataRow dr);
    }
}
