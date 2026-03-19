using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract(IsReference = true)]
public class User
{
    /// <summary>
    /// The email address of the user. It's used as the login of the user.
    /// </summary>
    [Key]
    [DataMember]
    public string Email { get; set; }


    /// <summary>
    /// The name of the user.
    /// </summary>
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// The date and time when the user was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the user was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    #region Navigation Properties

    /// <summary>
    /// A list of job this user created.
    /// </summary>
    [DataMember]
    public List<Job> Jobs { get; set; }

    #endregion

    public void Init(string email, string name)
    {
        Email = email;
        Name = name;
        Created = DateTime.UtcNow;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }

    public void Rename(string newname)
    {
        Name = newname;
        Update();
    }
}
