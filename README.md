# OOP10FEXLab

Fast food **Kiosk** and **Queue Monitor** in C# Windows Forms — OOP10 Final Laboratory Exam.

See [PRD.md](PRD.md) for the requirements and [members.txt](members.txt) for the group.

## Team

| Member | Role | GitHub |
| --- | --- | --- |
| Ian Patrick A. Flores | Repository Owner, Team Lead, Backend | [@Muj-csv](https://github.com/Muj-csv) |
| Mary Princess Angel L. Dizon | UI/UX | [@mpadzn](https://github.com/mpadzn) |
| Joey T. Cuison | Frontend | [@joeycuison333-stack](https://github.com/joeycuison333-stack) |

## Getting started

**Needs:** Windows + Visual Studio 2019/2022 (.NET desktop development, .NET Framework 4.7.2).

1. Clone the repo:
   ```bash
   git clone https://github.com/Muj-csv/OOP10FEXLab.git
   ```
2. Open `OOP10FEXLab.sln` in Visual Studio.
3. Press **F5**. The **Queue Monitor** and the **Kiosk** open together.

## How to use

1. **Kiosk:** Dine In / Take Out → tap meals → **Review & Pay** → **Place Order** → get an order number.
2. **Queue Monitor:** the number shows under **PREPARING**. Click it → **NOW SERVING**. Click again → **Claimed** (removed).

## Files

```
OOP10FEXLab/
├─ OOP10FEXLab.sln
├─ README.md
├─ PRD.md
├─ members.txt
└─ OOP10FEXLab/
   ├─ Program.cs                 opens the Monitor and the Kiosk
   ├─ Models/                    Meal, Order, OrderItem
   ├─ Services/Cart.cs           current order
   ├─ Data/
   │  ├─ meals.txt               package meals (edit to change the menu)
   │  ├─ MealRepository.cs       reads meals.txt
   │  └─ TransactionRepository.cs  saves orders to transactions.txt
   └─ UI/                        KioskForm, CheckoutForm, ReceiptForm, QueueMonitorForm, MealCard, Theme
```

- **Menu:** edit `Data/meals.txt` — `Code|Category|Name|Price|Inclusions`.
- **Transaction record:** `bin/Debug/Data/transactions.txt`, created on the first order.
- **Store name and colors:** `UI/Theme.cs`.
- **Database:** put the instructor's connection/query code inside `MealRepository` and `TransactionRepository`.
