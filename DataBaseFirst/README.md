# DataBaseFirst
The Database First Approach creates the entity framework from an existing database.<br/>
[This video and step-by-step walkthrough provide an introduction to Database First development using Entity Framework](https://msdn.microsoft.com/en-us/library/jj206878(v=vs.113).aspx)<br/>
<br/>
<br/>
Using entity,you can manage database resources by adding new elements , deleting , changing information that saved in database.<br/>
(In this code I have UsersEntity, MyUsers table whith columns Name,eMail and Password)<br/>
Entity lets to manage database information with simple c# commands .
```cs
using (var context = new UsersEntities())
{
    //read data using Entity 
    var users = context.MyUsers.ToList();
    foreach (var user in users)
        Console.WriteLine(user.eMail);

    //adding new element
    MyUser myuser = new MyUser();
    myuser.Name = "name";
    myuser.eMail = "email";
    myuser.Password = "password";

    context.MyUsers.Add(myuser);

    //removing elements
    var delete_users = from b in context.MyUsers
                       where b.Name == "name"
                       select b;
    foreach (var m in delete_users)
        context.MyUsers.Remove(m);

    context.SaveChanges();
}
```
Entity also lets to manage database with SQL commands
```cs
using (var context = new UsersEntities())
{
     context.Database.ExecuteSqlCommand("SQL command line");
     context.SaveChanges();
}
```
## Here are some needful commands of SQL

* <b>for adding new element </b> <br/>
insert into <i>Table_Name</i>(Column_1, Column_2, ...) Values('value_1', 'value_2', ...)

* <b>for deleting element(s) </b><br/>
delete from <i>Table_Name</i> where <i>Column_name</i>='value'

* <b>to change something with given value</b> <br/>
update <i>Table_Name</i> set <i>Column_Name</i>='new value' where <i>Column_Name</i>='given_value' <br/>
(or another_column_name='value')
