using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;


namespace PhotoStore.ApplicationServices
{
    public class EventoApplicationService : GenericApplicationService<Evento>, IEventoApplicationService
    {
        public EventoApplicationService(IEventoService svc) : base(svc)
        {

        }
    }
}
