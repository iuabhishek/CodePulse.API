using CodePulse.Application.Abstractions.Repositories;
using CodePulse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.Application.Features.Categories.Queries
{
    public record GetAllCategoryQuery():IRequest<IEnumerable<Category>>;

    public class GetCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository repository;

        public GetCategoryQueryHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        
        public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllCategoryAsync();
        }
    }
}
