using CodePulse.Application.Abstractions.Repositories;
using CodePulse.Domain.Entities;
using MediatR;

namespace CodePulse.Application.Features.Categories.Command
{
    public record UpdateCategoryCommand(Guid Id, Category category):IRequest<Category?>;

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Category?>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryHandler(ICategoryRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Category?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Id, request.category);
        }
    }

}
