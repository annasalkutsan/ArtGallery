using Domain.Primitives;
using Domain.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Author:BaseEntity
{
    public Author(){}

    public Author(int numberOfWorks, string? description, User user)
    {
        NumberOfWorks = numberOfWorks;
        Description = description;
       
       // var validator = new AuthorValidator();
      //  validator.ValidateAndThrow(this);
    }
    public int NumberOfWorks { get; set; }
    public string? Description { get; set; }

    public FullName FullName { get; set; }
    public ICollection<Painting> Paintings { get; set; } = new List<Painting>();
    
    public Author Update(int? numberOfWorks, string? description)
    {
        if (numberOfWorks.HasValue)
        {
            NumberOfWorks = numberOfWorks.Value;
        }

        if (description is not null)
        {
            Description = description;
        }

       // var validator = new AuthorValidator();
       // validator.ValidateAndThrow(this);

        return this;
    }
}