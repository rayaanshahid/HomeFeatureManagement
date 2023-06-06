# HomeFeatureManagement

## Run the API

Run the API in Visual studio and the Swagger is available at https://localhost:7194/swagger/index.html

## Input

The body consists of following Json

```json
{
  "propertyId": "id1",
  "address": "pilestredet",
  "floors": 3,
  "type": "HOUSE",
  "features": [
    "balcony"
  ]
}
```

Field validation are imposed so if you go outside of this list It will throw exceptions

Type should be one of the following values: house, apartment, serialhouse

Features: balcony, fireplace, parking, elevator, morning_sun, evening_sun






