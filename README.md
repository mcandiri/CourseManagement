
# Course Management Project

Welcome to the **Course Management Project**! This repository contains a simplified version of a course registration system, designed as a performance task for software developer candidates applying to our company. Your goal is to complete the project by implementing specific business logic and ensuring the application meets the requirements outlined below.

## Project Overview

This project is a web-based system built using **.NET Core MVC**. The system allows students to register for various courses, and also allows deregistration from those courses. It includes a few models such as `Student`, `Course`, and `StudentCourse` as well as a service layer (`ReservationService`) where you will implement the core business logic.

The main objective of this project is to evaluate your skills in:
- Writing clean, maintainable, and efficient C# code.
- Implementing business logic based on given requirements.
- Writing tests to validate functionality.
- Understanding and using basic design patterns where applicable.

## Task Instructions

1. **Fork the Repository**: Begin by forking this repository to your personal GitHub account. This will allow you to work independently on your own copy of the project.

2. **Implement Business Logic**: Your main task is to implement the following methods within the `ReservationService` class:
   - `RegisterStudentToCourseAsync(int courseId, int studentId)`: Implement logic to register a student to a course.
     - Check if the course has available capacity.
     - Ensure the student is not already registered for the course.
     - Update the available slots in the course.
     - Add an entry in the `StudentCourse` table.
   - `DeregisterStudentFromCourseAsync(int courseId, int studentId)`: Implement logic to deregister a student from a course.
     - Remove the student-course relationship.
     - Update the available slots in the course accordingly.

3. **Testing**: The `CourseRegistrationTests` class is provided for you. Please do **not modify** the existing tests, but make sure your implementations pass these tests successfully.

4. **Commit and Push Changes**: Commit your changes regularly with meaningful commit messages. Once you're finished, push your changes to your forked repository.

5. **Create a Pull Request (PR)**: After completing the task, create a Pull Request from your forked repository to this main repository. In your PR description, provide a summary of the changes you've made and any relevant details.

## Requirements and Guidelines

- You should not modify the existing **mock data** or the **provided tests**. Your implementation should work with the given setup.
- Write **clean and readable code**. We value code that is easy to understand and maintain.
- Use **asynchronous programming** where applicable, following best practices for performance.
- Ensure your implementation properly handles edge cases, such as when a course is already full or a student tries to register twice.
- **Document your code** where necessary to explain complex logic or assumptions.

## Evaluation Criteria

Your submission will be evaluated based on the following criteria:
- **Correctness**: Your implementation meets the outlined requirements and passes all tests.
- **Code Quality**: Your code should be clean, well-organized, and follow best practices.
- **Problem-Solving**: How well you handle edge cases and the logical flow of your implementation.
- **Commit History**: Meaningful commit messages and regular commits to show progression in your work.

## Getting Started

To get started, you will need:
- **.NET 6 SDK** or later installed on your local machine.
- A code editor like **Visual Studio** or **Visual Studio Code**.
- Familiarity with **Git** for version control.

  
## FAQ
Q: Can I modify the provided models or repositories?
A: No, the models and repositories should remain unchanged. Your implementation must work with the existing setup.

Q: Can I add extra helper methods?
A: Yes, you may add helper methods within the ReservationService class if needed, as long as they are relevant and improve code clarity.

Q: What should I do if I can't complete the task?
A: Submit your progress and include a note explaining your thought process and any challenges faced.


### Running the Application
1. Clone your forked repository to your local machine.
2. Open the project in your preferred editor.
3. Use the terminal to run the application with the following command:
   ```bash
   dotnet run
   ```
4. Run the tests to ensure everything is working correctly:
   ```bash
   dotnet test
   ```

## Contact

If you have any questions about this task, feel free to reach out. We are looking forward to seeing your approach and how you solve this challenge. Good luck, and happy coding!

**Veritas Academy**

Email: mehmetcan@veritasedu.net
