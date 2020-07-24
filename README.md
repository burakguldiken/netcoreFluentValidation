
# Fluent Validation

### About

performs control of request parameters

### Code Example

```csharp
Customer customer = new Customer();
customer.lastname = "lastname test";
customer.surname = "surname test";
```

```csharp
RuleFor(x => x.surname).NotEmpty();
RuleFor(x => x.lastname).NotEmpty().WithMessage("Please specify a first name");
```

```csharp
ValidationResult results = validator.Validate(customer);
```
