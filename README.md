# Amazonaz
ASP.NET Core Web API

## Project Request

Entities: 
* Users
* Orders
* Products


### Users
| Association | ColumnName | Datatype | Nullable |
| -- | -- | -- | -- | 
| PK | Id | Guid | NOT NULL |
| | FirstName | nvarchar(32) | NOT NULL |
| | LastName | nvarchar(32) | NOT NULL |
| | Address | nvarchar(64) | NOT NULL |

### Orders
| Association | ColumnName | Datatype | Nullable |
| -- | -- | -- | -- | 
| PK | Id | Guid | NOT NULL |
| FK | UserId | Guid | NOT NULL |
| FK | ProductId | Guid | NOT NULL |
| | Quantity | int | NOT NULL |
| | ToAdress | nvarchar(64) | NOT NULL |
| | OrderDate | DateTime2 | NOT NULL |

### Products
| Association | ColumnName | Datatype | Nullable |
| -- | -- | -- | -- | 
| PK | Id | Guid | NOT NULL |
| | TotalSupply | int | NOT NULL |
| | Price | Double | NOT NULL |
| | Name | nvarchar(32) | NOT NULL |
| | Description | nvarchar(64) | NULL |
| | CreationDate | DateTime2 | NOT NULL |
| FK | CreatedById | Guid | NOT NULL |

