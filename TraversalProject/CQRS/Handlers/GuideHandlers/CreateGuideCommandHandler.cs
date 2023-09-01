using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalProject.CQRS.Commands.GuideCommands;

namespace TraversalProject.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken) // Unit => void gibi hareket eden tür
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value; // Unit.Value=> Bu sınıfın talebi işleyip bir boşluk döndüreceğini belirtiyor. Kullanırken geçersiz yerine, bir geçersiz türü temsil eden yapıyı kullanıyor.
        }
    }
}
