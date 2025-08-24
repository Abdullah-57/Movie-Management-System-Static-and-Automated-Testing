# Movie Management System Quality Assurance Repository

This repository contains quality assurance artifacts for the Movie Management System (MMS), a MERN stack application that includes a comprehensive test plan, static code analysis report highlighting reliability, maintainability, and code duplication issues, and defect reports documenting identified bugs with reproduction steps and screenshots.

---

## 🌐 Overview

The test plan outlines testing strategies for functional, integration, performance, security, and UI aspects of MMS modules like movie management, user authentication, reviews, recommendations, subscriptions, notifications, and watch history. The static analysis report uses tools to identify code smells and improvements. Defect reports detail issues such as invalid input handling in subscription forms.

This repository serves as a resource for understanding software testing, static analysis, and defect management practices in a full-stack web application.

---

## 🚀 Getting Started

### Prerequisites

🔹 Node.js (v16.x or later)\
🔹 MongoDB Atlas\
🔹 React.js (v18.x or later)\
🔹 Testing tools: Jest, Supertest, Postman, JMeter, SonarQube/ESLint

### Installation

- Clone the repository:

  ```bash
  git clone https://github.com/username/mms-quality-assurance.git
  ```
- Navigate to the project directory:

  ```bash
  cd mms-quality-assurance
  ```

---

## 📁 Documents Overview

🔹 **Test_Plan.docx**: Master test plan following IEEE 829, covering scope, features, test approach, pass/fail criteria, roles, and risks.\
🔹 **Static_Analysis_Report.docx**: Report on code reliability (e.g., error handling issues), maintainability (e.g., complex methods), and duplication, with visualizations.\
🔹 **Defect_Reports.doc**: Jira-style defect logs, including bug descriptions, reproduction steps, and screenshots (e.g., negative price input in subscriptions).

---

## 🔍 Testing Approach

- **Functional & Integration**: Manual and automated tests for modules and interactions.
- **Performance**: Load testing with JMeter for response times under concurrent users.
- **Security**: Penetration tests for vulnerabilities like SQL injection and XSS.
- **UI**: Cross-browser and device responsiveness with Selenium.
- **Regression**: Automated suites to ensure stability post-fixes.

---

## 📊 Static Analysis Highlights

🔹 **Reliability**: Issues like unhandled exceptions and potential null pointers.\
🔹 **Maintainability**: High cyclomatic complexity in recommendation engine.\
🔹 **Code Duplication**: Repeated logic in user and movie CRUD operations.

---

## 🐞 Defect Management

- Defects tracked with IDs, priorities, and resolutions.
- Example: Defect ID 1 - Negative price allowed in subscription form, leading to data integrity issues.

---

## 💡 Improvement Recommendations

🔹 Enhance input validation for forms.\
🔹 Refactor duplicated code using DRY principles.\
🔹 Increase test coverage for edge cases in recommendations and payments.\
🔹 Mock external APIs (e.g., Stripe) for reliable testing.

---


## 👨‍💻 Contributors
- **Abdullah Daoud (22I-2626)**  
- **Usman Ali (22I-2725)**  
- **Faizan Rasheed (22I-2734)**

---

## ⚖️ License
This project is for **academic and personal skill development purposes only**.  
Reuse is allowed for **learning and research** with proper credit.

---
