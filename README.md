
# Course Management Project

Welcome to the **Course Management Project**! This repository contains a simplified version of a course registration system, designed as a performance task for software developer candidates applying to our company. Your goal is to complete the project by implementing specific business logic and solving additional algorithm challenges to ensure the application meets the requirements outlined below.

---

## **Project Overview**

This project is a web-based system built using **.NET Core MVC**. The system allows students to register for various courses and also allows deregistration from those courses. It includes a few models such as `Student`, `Course`, and `StudentCourse` as well as a service layer (`ReservationService`) where you will implement the core business logic.

Additionally, we have included two algorithm challenges under the `AlgorithmTasks` namespace. These tasks are independent of the main course management logic and are designed to test your ability to work with algorithms and collections.

The main objective of this project is to evaluate your skills in:
- Writing clean, maintainable, and efficient C# code.
- Implementing business logic based on given requirements.
- Solving algorithmic problems.
- Writing tests to validate functionality.
- Understanding and using basic design patterns where applicable.

---

## **Task Instructions**

### **Business Logic Implementation**
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

---

## **Algorithm Challenges**
The algorithm challenges are located in the `AlgorithmTasks` namespace. These challenges are independent of the main course management logic and are designed to test your ability to work with algorithms and collections.

#### **Challenge 1: Longest Increasing Subarray**
- **File:** `AlgorithmTasks/LongestIncreasingSubarray.cs`
- **Problem:** Write a function that finds the longest subarray of consecutive increasing numbers in a list. The sequence must maintain the original order of the list.
- **Function Signature:**
  ```csharp
  public static List<int> FindLongestIncreasingSubarray(List<int> numbers)
  ```
- **Example 1:**
  - **Input:** `[10, 22, 9, 33, 21, 50, 70, 41, 60]`
  - **Output:** `[21, 50, 70]`
- **Example 2:**
  - **Input:** `[20, 25, 3, 9, 12, 7, 5, 9]`
  - **Output:** `[3, 9, 12]`

#### **Challenge 2: Most Frequent Character**
- **File:** `AlgorithmTasks/MostFrequentCharacter.cs`
- **Problem:** Write a function that takes a string and returns the most frequently occurring character along with its frequency. If multiple characters have the same frequency, return the alphabetically smallest.
- **Function Signature:**
  ```csharp
  public static (char character, int count) FindMostFrequentCharacter(string input)
  ```
- **Example 1:**
  - **Input:** `"character"`
  - **Output:** `('c', 2)`
- **Example 2:**
  - **Input:** `"mississippi"`
  - **Output:** `('i', 4)`

---

## **Requirements and Guidelines**

- You should not modify the existing **mock data** or the **provided tests** for the course management logic.
- For algorithm challenges, write your implementations directly in the respective files (`LongestIncreasingSubarray.cs` and `MostFrequentCharacter.cs`).
- Write **clean and readable code**. We value code that is easy to understand and maintain.
- Use **asynchronous programming** where applicable, following best practices for performance.
- Ensure your implementation properly handles edge cases.
- **Document your code** where necessary to explain complex logic or assumptions.

---

## **Evaluation Criteria**

Your submission will be evaluated based on the following criteria:
- **Correctness**: Your implementation meets the outlined requirements and passes all tests.
- **Code Quality**: Your code should be clean, well-organized, and follow best practices.
- **Problem-Solving**: How well you handle edge cases and the logical flow of your implementation.
- **Commit History**: Meaningful commit messages and regular commits to show progression in your work.

---
## **Pull Request Submission**

Once you have completed the project, follow these steps to submit your work:
1. Fork this repository to your personal GitHub account.
2. Create a new branch from `main`. Example:
   ```bash
   git checkout -b yourname/solution
   ```
3. Commit your changes regularly with clear and meaningful messages.
4. Push your changes to your forked repository. Example:
   ```bash
   git push origin yourname/solution
   ```
5. Create a Pull Request (PR) from your forked repository to this main repository:
   - Provide a descriptive title, e.g., `YourName - Course Management Solution`.
   - Include a brief description of your solution and any challenges you faced.
   - Optional: Suggest any improvements or additional features.

---

## **Getting Started**

To get started, you will need:
- **.NET 6 SDK** or later installed on your local machine.
- A code editor like **Visual Studio** or **Visual Studio Code**.
- Familiarity with **Git** for version control.

---

## **FAQ**

**Q:** Can I modify the provided models or repositories?  
**A:** No, the models and repositories should remain unchanged. Your implementation must work with the existing setup.

**Q:** Can I add extra helper methods?  
**A:** Yes, you may add helper methods within the `ReservationService` class if needed, as long as they are relevant and improve code clarity.

**Q:** What should I do if I can't complete the task?  
**A:** Submit your progress and include a note explaining your thought process and any challenges faced.

---

## **Running the Application**

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

---

## **Contact**

If you have any questions about this task, feel free to reach out. We are looking forward to seeing your approach and how you solve this challenge. Good luck, and happy coding!

**Veritas Academy**  
Email: mehmetcan@veritasedu.net
