using CodePulse.Application.Abstractions.Repositories;
using CodePulse.Domain.Entities;
using MediatR;

namespace CodePulse.Application.Features.Categories.Command
{
    public record class CreateCategoryCommand(Category Category) : IRequest<Category>;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateAsync(request.Category);
        }


    }
}
