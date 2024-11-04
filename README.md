# 🍰 Cake Delivery Website

## 👋 Introduction
The Cake Delivery App is a full-stack web application built using .NET 0.8 for the backend, Web APIs, SQL for database management, and React for the frontend. The app enables customers to browse a catalog of cakes, customize orders, and place secure orders with automated location detection. The system also includes an admin panel for managing cakes, categories, customers, and users, providing a smooth experience for both customers and administrators.

<div align="center" style="display:flex;">
  <img src="https://imgur.com/ZLoENuD.jpg" alt="App Screenshot 1" width="400"/>
  <img src="https://imgur.com/CPLTVBK.jpg" alt="App Screenshot 2" width="400"/>
</div>

## 🚀 Features

### Customer App

- **Cake Catalog**  
  Customers can explore a wide range of cakes organized by categories, making it easy to find the perfect cake.
  <div align="center">
    <img src="https://imgur.com/kihMZ7l.jpg" alt="Cake Catalog" width="400"/>
  </div>

- **Order Customization**  
  Customers can personalize their orders by selecting specific cake sizes and quantities, then add these customized cakes to their shopping cart for easy management before checkout.
  <div align="center">
    <img src="https://imgur.com/oQb5Eeu.jpg" alt="Customized Order" width="200"/>
  </div>

- **Location Auto-Detection**  
  With Leaflet React integration, the app automatically detects customer location during checkout, simplifying the process by eliminating the need to manually enter addresses, especially useful for mobile users.
  <div align="center">
    <img src="https://imgur.com/2HBOiEJ.jpg" alt="Location Detection" width="200"/>
  </div>

- **Secure Checkout**  
  The checkout process gathers essential customer contact details, payment information, and confirms the auto-detected delivery address, ensuring a smooth and secure ordering experience.
  <div align="center">
    <img src="https://imgur.com/OlTjj5S.jpg" alt="Secure Checkout" width="200"/>
  </div>

- **Feedback System**  
  After completing an order, customers are invited to leave feedback on their experience. These reviews are displayed on the homepage, allowing new visitors to view real testimonials from other customers.

- **Dynamic Homepage**  
  - **Recently Added Cakes**: Highlights the newest additions to the catalog, encouraging customers to return and explore fresh options.
  - **Customer Feedback & Testimonials**: Displays real feedback from customers, adding credibility and helping new users make informed decisions.
  - **Contact Information**: Essential contact details are prominently displayed, making it easy for customers to reach out with questions or special requests.
  <div align="center">
    <img src="https://imgur.com/3kcQU1F.jpg" alt="Homepage Features" width="200"/>
  </div>
### 📈 Admin Panel
- **Admin Login Page**
Provides secure login access to the admin panel, ensuring that only authorized users can manage the app’s data and functionalities.
  <div align="center">
    <img src="https://imgur.com/CtR2gF6.jpg" alt="Homepage Features" width="200"/>
  </div>
- **Dashboard Overview**
The admin dashboard provides a quick summary of sales for the week, allowing administrators to see business performance metrics at a glance, identify trends, and make data-driven decisions.
  <div align="center">
    <img src="https://imgur.com/yhd5074.jpg" alt="Homepage Features" width="200"/>
  </div>
- **Cake Management**
A dedicated Cakes page gives admins the ability to view, add, update, or remove cakes from the catalog.
Stock Quantity Control: Admins can adjust the quantity of each cake in stock to ensure accurate availability for customers.
  <div display="flex" align="center">
    <img src="https://imgur.com/l75vRke.jpg" alt="Homepage Features" width="200"/>
    <img src="https://imgur.com/gUbM8o1.jpg" alt="Homepage Features" width="200"/>
  </div>
- **Category Management**
The Categories page organizes cakes into classifications (e.g., birthday, anniversary, weedings ..), making the catalog easy for customers to navigate. Admins can add new categories, edit existing ones, or delete outdated ones.
  <div align="center">
    <img src="https://imgur.com/bY2XIhK.jpg" alt="Homepage Features" width="200"/>
  </div>
- **Customer Management**
Admins can access a complete list of customers who have placed orders, providing insight into customer behavior and allowing them to address any account-specific inquiries or issues.
<div align="center">
    <img src="https://imgur.com/vzJKv8M.jpg" alt="Homepage Features" width="200"/>
</div>

- **User Management**
Admins can create new user accounts for additional staff members, manage existing user information, and update email addresses or reset passwords when needed, ensuring smooth and secure system operation.
<div align="center">
    <img src="https://imgur.com/Qcrp49T.jpg" alt="Homepage Features" width="200"/>
</div>

   ## 🛠️Technologies Used
### Database
 - **Database: Microsoft SQL Server with ADO.NET.**
### Frontend
- **Build Tool: Vite for efficient project building.**
- **React Query :  for remote state management & data fetching.**
- **Context API for UI state management.**
- **React Router : to implement routing.**
- **TailwindCSS: for styling.**
- **React Hook Form for managing forms.**
- **Recharts : library for charts to show statistics.**
- **react-hot-toast : for toast notifications.**
- **react-icons : for UI icons.**
### backend
- **Controllers:**
  - Organize and handle HTTP requests for resources (e.g., Cakes, Orders).
  - Define CRUD actions via HTTP methods (GET, POST, PUT, DELETE).

- **Models/DTOs:**
  - Define data structures to streamline client-server data transfer.

- **HTTP Methods:**
  - GET: Retrieve resources (e.g., list of cakes).
  - POST: Create new resources (e.g., submit an order).
  - PUT: Update existing resources (e.g., modify cake details).
  - DELETE: Remove resources (e.g., delete a cake).

- **Status Codes:**
  - 200 OK: Successful data retrieval/update.
  - 201 Created: Resource creation successful.
  - 204 No Content: Resource deleted successfully.
  - 400 Bad Request: Invalid data received.
  - 404 Not Found: Resource does not exist.

- **Validation:**
  - Ensures incoming data is accurate and secure.
  - Model attributes and custom logic enforce data requirements.
## 🚀 Live Demo
<a href="https://youtu.be/ZqCrSqjeXdg?si=leU7gdXsEMdJVfc_" alt="demo">🔗click me 😊!</a>
