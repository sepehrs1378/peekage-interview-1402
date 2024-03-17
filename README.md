# How to run

## Install requirements
```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Initialize database
Create initial migration.
```
dotnet ef migrations add InitialCreate
```

Do the migration.
```
dotnet ef database update
```

## Run server
Run the server on port 5000 of localhost.
```
dotnet run --urls="http://localhost:5000"
```

# SMS
SMSs will be showed in the terminal when the register request is made (/api/invoice/register).
An SMS has the id of the invoice and its total cost.

# APIs
## GET /api/invoice/getall
Returns a list of all invoices.

### Request
- Method: GET
- Path: `/api/invoice/getall`

### Response
- Status Code: 200 OK
- Body:
  ```json
  [
    {
        "id": 1,
        "buyerName": "User 1",
        "phoneNumber": "+989156250000",
        "items": [
            {
                "id": 1,
                "productName": "Product 1",
                "count": 2,
                "unitPrice": 10
            },
            {
                "id": 2,
                "productName": "Product 2",
                "count": 1,
                "unitPrice": 15
            }
        ],
        "totalCost": 35
    },
    {
        "id": 2,
        "buyerName": "User 2",
        "phoneNumber": "+989156250000",
        "items": [
            {
                "id": 3,
                "productName": "Product 1",
                "count": 2,
                "unitPrice": 10
            },
            {
                "id": 4,
                "productName": "Product 4",
                "count": 3,
                "unitPrice": 20
            }
        ],
        "totalCost": 80
    }
  ]
  ```

## GET /api/invoice/get/{id}
Returns the invoice with the given id.
### Request

- Method: GET
- Path: `/api/invoice/get/1`

### Response
- Status Code: 200 OK
- Body:
  ```json
  {
    "id": 1,
    "buyerName": "User 1",
    "phoneNumber": "+989156250000",
    "items": [
        {
            "id": 1,
            "productName": "Product 1",
            "count": 2,
            "unitPrice": 10
        },
        {
            "id": 2,
            "productName": "Product 2",
            "count": 1,
            "unitPrice": 15
        }
    ],
    "totalCost": 35
  }
  ```

## POST /api/invoice/register
Registers a new invoice.
### Request

- Method: POST
- Path: `/api/invoice/register`
- Body:
  ```json
  {
    "buyerName": "User 2",
    "phoneNumber": "+989156250000",
    "items": [
      {
        "productName": "Product 1",
        "count": 2,
        "unitPrice": 10
      },
      {
        "productName": "Product 4",
        "count": 3,
        "unitPrice": 20
      }
    ]
  }
  ```

### Response
- Status Code: 201 OK
- Body:
  ```json
  {
    "id": 2,
    "buyerName": "User 2",
    "phoneNumber": "+989156250000",
    "items": [
        {
            "id": 3,
            "productName": "Product 1",
            "count": 2,
            "unitPrice": 10
        },
        {
            "id": 4,
            "productName": "Product 4",
            "count": 3,
            "unitPrice": 20
        }
    ],
    "totalCost": 80
  }
  ```