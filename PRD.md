# PRD — OOP10FEXLab: Fast Food Kiosk & Queue Monitor

**Course:** OOP10 Final Laboratory Exam · **Date:** November 10, 2026

## 1. Overview

A C# Windows Forms app with two screens, similar to Jollibee, McDo and KFC:

- **Kiosk** — customers order package meals and get an order number.
- **Queue Monitor** — shows order numbers under **PREPARING** and **NOW SERVING**.

Package meals are read from a notepad file, and every order is saved to a transaction record.

## 2. Team

| Member | Role | GitHub |
| --- | --- | --- |
| Ian Patrick A. Flores | Repository Owner, Team Lead, Backend | [Muj-csv](https://github.com/Muj-csv) |
| Mary Princess Angel L. Dizon | UI/UX | [mpadizon](https://github.com/mpadizon) |
| Joey T. Cuison | Frontend | [joeycuison333-stack](https://github.com/joeycuison333-stack) |

## 3. Exam requirements

1. GitHub repo named `OOP10FEXLab`, all members invited.
2. A notepad file with the members' names (`members.txt`).
3. Two UIs: Queue Monitor and Kiosk.
4. Package meals retrieved from a database or notepad file.
5. Orders saved to a transactions record.

## 4. Kiosk

1. Welcome screen: **Dine In** or **Take Out**.
2. Category buttons on the left; meal tiles in the middle (IMAGE placeholder, name, inclusions, price, **+ ADD**).
3. **My Order** panel with − / + per meal.
4. Footer: **Cancel Order**, **Order Total**, **Review & Pay**.
5. Review screen → **Place Order** → order number and order slip.

## 5. Queue Monitor

1. Two columns: **PREPARING** and **NOW SERVING**, plus the store name and clock.
2. Refreshes every 2 seconds from the transaction record.
3. Crew clicks a number to move it: Preparing → Now Serving → Claimed (removed).

## 6. Data

**Package meals — `Data\meals.txt`** (one meal per line)

```
Code|Category|Name|Price|Inclusions
C1|Chicken Meals|1pc Chicken Meal|105|1pc Chicken, Rice, Drink
```

**Transaction record — `Data\transactions.txt`** (created on the first order, next to the .exe)

```
OrderNo|DateTime|DiningOption|Status|Total|Items
1001|2026-11-10 10:08:37|DineIn|Preparing|210.00|C1^1pc Chicken Meal^105^2
```

Order numbers start at 1001 each day. Status: `Preparing`, `NowServing`, `Claimed`.

## 7. Design

| Folder | Classes | Purpose |
| --- | --- | --- |
| `Models` | `Meal`, `Order`, `OrderItem` | Data objects |
| `Services` | `Cart` | The customer's current order |
| `Data` | `MealRepository`, `TransactionRepository` | Read `meals.txt`; save/read `transactions.txt` |
| `UI` | `KioskForm`, `CheckoutForm`, `ReceiptForm`, `QueueMonitorForm`, `MealCard`, `RoundedPanel`, `Theme` | Screens |

OOP used: **classes and objects**, **encapsulation** (`Cart` keeps its list private), **inheritance** (forms extend `Form`, `MealCard` extends `RoundedPanel`, which extends `Panel`), **events** (`Cart.Changed`, `MealCard.AddClicked`).

Look: red and yellow fast-food theme on a cream background, store name **AnDokiDoks**, rounded white cards, IMAGE placeholders where meal pictures go — all set in `UI\Theme.cs`.

## 8. Test checklist

- [ ] Kiosk shows 12 meals in 4 categories.
- [ ] Adding C1 twice shows ₱210.00; the total updates.
- [ ] Place Order shows order number 1001 (first of the day).
- [ ] The order appears in `transactions.txt` and under PREPARING.
- [ ] Clicking the number moves it to NOW SERVING, then removes it (Claimed).

## 9. Out of scope

Real payments, login, menu editor, sales reports, printing.

**Database — instructor's MySQL server** (`Data\DatabaseConnection.cs`, provided connection and sample queries, MySql.Data NuGet package)

- Menu: `SELECT package_name FROM package_tbl`; each package's code, category, price and inclusions come from `meals.txt` by name.
- Orders: `INSERT INTO transactions_tbl (package_name, transaction_date)`, one row per meal, all saved in one database transaction.
- The Queue Monitor still reads `transactions.txt`, because `transactions_tbl` has no order number or status.
- If the server cannot be reached, the menu comes from `meals.txt` and orders are saved to `transactions.txt` only.
