using System.Threading;
using System.Data;

namespace Sheduler.View {
    public interface IView {
        void ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt);
        SynchronizationContext GetContext();
    }
}
