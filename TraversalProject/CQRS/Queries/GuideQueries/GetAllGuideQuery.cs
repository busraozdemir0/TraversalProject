using MediatR;
using System.Collections.Generic;
using TraversalProject.CQRS.Results.GuideResults;

namespace TraversalProject.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
