using System;
using System.Data;

namespace Sheduler.Controller {
    public interface IWrite2Controller : IWriteController {
        void Refresh(DataTable dt, String link_id);
    }
}
