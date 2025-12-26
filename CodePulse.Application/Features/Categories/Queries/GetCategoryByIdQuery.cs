using CodePulse.Application.Abstractions.Repositories;
using CodePulse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.Application.Features.Categories.Queries
{
     public record GetCategoryByIdQuery(Guid Id) : IRequest<Category?>;


    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category?>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryByIdHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCategoryByIdAsync(request.Id);
        }
    }


}
