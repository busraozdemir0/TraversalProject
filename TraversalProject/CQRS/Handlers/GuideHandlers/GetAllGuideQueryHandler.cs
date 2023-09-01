using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TraversalProject.CQRS.Queries.GuideQueries;
using TraversalProject.CQRS.Results.GuideResults;

namespace TraversalProject.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler: IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>> // MediatR ile kullanım
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID= x.GuideID,  // x Guide sınıfının propertylerini tutuyor
                Description=x.Description,
                Image=x.Image,
                Name=x.Name,
            }).AsNoTracking().ToListAsync();
        }
    }
}
