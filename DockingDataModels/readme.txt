
[Design]

There are two different designs about docking model version control.
(1) Hash-based version control:
    No version information is stored in the database.
    Everytime a docking is performed, acquire the model hash and store the docking score for the hash in the snapshot table and store the result conformation in a hash-specific folder.
    All results are job-specific and duplicate results may exist in the database if two results share the same ligand and protein model. Future access to the historical results is easy.
    Result table contains information about snapshots in order to enable access to the correct resulting conformations.
    Reuse of resulting scores and conformations depend on snapshots.
    New tasks cannot reuse old models for computation. Once a protein model is updated, it's not possible to compute against the old version.
    Domain proteins are updated one by one. It's not possible to draft a new domain version and release it when all new protein models are ready.
    Only the latest version of receptor conformations, chembl compounds and trained models are stored in the receptor folder.
(2) Database-based version control:
    Versioned entities are stored in dedicated tables. All historical versions are stored in the database.
    Domain, Protein, ProteinCavity, ChemblCompounds and TrainedModels have their own versioned tables.
    A structure is used by versioned protein cavity. A task uses versioned domains. A result is for versioned protein cavity. A ligand need no version control.
    Domain references Protein, Protein references ProteinCavity, while versioned Domain references versioned Protein, versioned Protein references versioned ProteinCavity.
    A task is created with a versioned domain.
    Everytime a model, a chembl compound set or a trained model updates, the version number increments.
    All resulting conformations are stored in a version-specified folder. The receptor folder also uses version-specific folders to store models.


[Handling formatters]

https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-3.0
https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/json-and-xml-serialization

Use DataContract annotations for serializing into Json and Xml.

By default, the formatter serializes all public readable and writeable properties. With a [DataContract] attribute defined, the formatter begins to use the opt-in rule instead.


[Owned entities]

Currently Owned entities have some limitations:
https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities#limitations

A reference navigation to an owned entity type cannot be null but as a reference type its default value is null.
If we didn't assign an entity to the navigation before saving it to the database it will be retrieved as a null value and re-assigning an entity to it is not trivial.
The entity framework tracks all entity status. Adding a new entity to the context typically requires a _ctx.Entities.Add() or _ctx.Add() call.
Since we are not actually adding the owned entity to the database, we need a different way to notify context:
   _ctx.Entry(obj).Reference(o => o.OwnedNavigation).TargetEntry.State = EntityState.Modified;
Otherwise the _ctx.SaveChanges() call will throw an exception.

With that navigation assigned an entity, we can no longer assign it back to null except that all properties are nullable in the model definition.
Since the navigation itself has no storage, the context considers the navigation null when all properties are null.
So by assigning all properties null and save the changes, the context will mark the navigation null.

Data seeding an owned navigation is also tricky since in the data seeding stage, no navigation assignment is allowed.
The main object should be added first:
    modelBuilder.Entity<MainObj>().HasData(new MainObj { Id = 1 });
Then initialize the owned navigation with an anonymous object:
    modelBuilder.Entity<MainObj>().OwnsOne(o => o.OwnedObj).HasData(new { OwnedValue = "value", MainObjId = 1 });
Where the MainObjId is a shadow property which doesn't really exist in the OwnedObj model.


Guideline:
Always initialize owned navigations with an entity.
Do not assign null to owned navigations.
Better have at least one property non-nullable in the owned model.
If all properties are nullable, keep at least one property not null.
If in case all properties should be null, remember to mark the navigation modified while assigning a new entity to it.
