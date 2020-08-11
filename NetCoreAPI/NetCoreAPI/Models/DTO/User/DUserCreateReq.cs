using FluentValidation;
using System;
using System.Collections.Generic;

namespace NetCoreAPI.Models.DTO.User
{
    public class DUserCreateReq
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Cpf { get; set; }
        public String Password { get; set; }
        public int? GroupId { get; set; }
        public List<int> Roles { get; set; }
    }

    public class DUserCreateReqValidator : AbstractValidator<DUserCreateReq>
    {
        public DUserCreateReqValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(v => v.Email)
                .NotEmpty()
                .MaximumLength(150)
                .EmailAddress();

            RuleFor(v => v.Cpf)
                .NotEmpty()
                .MaximumLength(11);

            RuleFor(v => v.Password)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(v => v.GroupId)
                .NotEmpty()
                .GreaterThanOrEqualTo(1);

            RuleFor(v => v.Roles)
                .NotEmpty();
        }
    }
}
