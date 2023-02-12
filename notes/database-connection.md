# How can we connect an application to a database?

In an application we'll have a client component that will be used by the end user. It's called frontend in the web applications case and app in the mobile application case.

The frontend connects to a backend that makes the connection to the database, this is done to provide security.

```
Frontend -> Backend -> Database
```

**Entity framework** is in charge of simplifying how we build the backend.

## Connection types

* **ODBC**
* **OLEDB**
* **SQL** Server
* Azure **SQL**

In the case of the first two, they are drivers and through a string we make the connection.