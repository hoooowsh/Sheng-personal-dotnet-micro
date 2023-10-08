# Plan Micro API

- [Plan Micro API](#plan-micro-api)
  - [Create Plan](#create-plan)
    - [Create Plan Request](#create-plan-request)
    - [Create Plan Response](#create-plan-response)
  - [Get Plan](#get-plan)
    - [Get Plan Request](#get-plan-request)
    - [Get Plan Response](#get-plan-response)
  - [Update Plan](#update-plan)
    - [Update Plan Request](#update-plan-request)
    - [Update Plan Response](#get-plan-response)
  - [Delete Plan](#delete-plan)
    - [Delete Plan Request](#update-plan-request)
    - [Delete Plan Response](#update-plan-response)
  - [Get Plan In Time Range](#get-plan-in-time-range)
    - [Get Plan In Time Range Request](#get-plan-in-time-range-request)
    - [Get Plan In Time Range Response](#get-plan-in-time-range-response)

## Create Plan

### Create Plan Request

```
POST /plan
```

```json
{
  "name": "Plan One",
  "content": "Content",
  "category": "Study",
  "insertDate": "2022-04-08T08:00:00",
  "startDate": "2022-04-08T08:00:00",
  "endDate": "2022-04-08T08:00:00",
  "impartanceLevel": "Medium"
}
```
