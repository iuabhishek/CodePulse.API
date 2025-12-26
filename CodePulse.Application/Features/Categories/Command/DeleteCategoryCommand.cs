using CodePulse.Application.Abstractions.Repositories;
using CodePulse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.Application.Features.Categories.Command
{
    public record DeleteCategoryCommand(Guid Id):IRequest<Category?>;

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category?>
    {
        private readonly ICategoryRepository _repository;
        public DeleteCategoryHandler(ICategoryRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Category?> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCategoryByIdAsync(request.Id);
        }
    }

}
