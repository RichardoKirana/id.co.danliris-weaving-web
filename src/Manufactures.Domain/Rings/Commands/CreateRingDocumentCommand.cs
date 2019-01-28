﻿using FluentValidation;
using Infrastructure.Domain.Commands;

namespace Manufactures.Domain.Rings.Commands
{
    public class CreateRingDocumentCommand : ICommand<RingDocument>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class CreateRingDocumentCommandValidator : AbstractValidator<CreateRingDocumentCommand>
    {
        public CreateRingDocumentCommandValidator()
        {
            RuleFor(command => command.Code).NotEmpty();
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
}
