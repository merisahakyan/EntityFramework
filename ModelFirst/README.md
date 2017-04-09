# Model First
Model First allows you to create a new model using the Entity Framework Designer and then generate a database schema from the model. <br/>
[This video and step-by-step walkthrough provide an introduction to Model First development using Entity Framework.](https://msdn.microsoft.com/en-us/library/jj205424(v=vs.113).aspx)
<br/><br/>
Using entity,you can manage database resources by adding new elements , deleting , changing information that saved in database.<br/>
(In this code I have UserContainer, Users table whith columns username)<br/>
Entity lets to manage database information with simple c# commands .
```cs
using (var context = new UsersEntities())
{
     using (var context = new UserContainer())
            {
                var user = new User { username = "name" };
                context.Users.Add(user);
                
                context.SaveChanges();
            }
}
```
Entity also lets to manage database with SQL commands
```cs
using (var context = new UserContainer())
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
