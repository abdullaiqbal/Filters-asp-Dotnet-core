# Filters-asp-Dotnet-core
1. "AllFilters.cs" File contains All the filters related to the Action
2. In "Pregram.cs" File:
//This Will Apply On All The Actions
 builder.Services.AddMvc(options =>
{
    options.Filters.Add(new AllFilters());
});

// Register IActionResponseTimeStopwatch
builder.Services.AddScoped<IActionResponseTimeStopwatch, ActionResponseTimeStopwatch>();
