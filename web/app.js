const gradePoints = { A: 4, B: 3, C: 2, D: 1, F: 0 };
const courseList = document.querySelector("#course-list");
const courseCount = document.querySelector("#course-count");
const score = document.querySelector("#gpa-score");
const scoreFill = document.querySelector("#score-fill");
const resultCopy = document.querySelector("#result-copy");
const totalCredits = document.querySelector("#total-credits");
const qualityPoints = document.querySelector("#quality-points");

function addCourse(name = "", grade = "A", credits = "3") {
  const row = document.createElement("div");
  row.className = "course-row";
  row.innerHTML = `
    <input aria-label="Course name" placeholder="Course name" value="${name}">
    <select aria-label="Grade">
      ${Object.keys(gradePoints).map((option) => `<option${option === grade ? " selected" : ""}>${option}</option>`).join("")}
    </select>
    <input aria-label="Credits" type="number" min="0.5" step="0.5" value="${credits}">
    <button class="remove-button" type="button" aria-label="Remove course">&times;</button>`;
  row.querySelector(".remove-button").addEventListener("click", () => { row.remove(); calculate(); });
  row.querySelectorAll("input, select").forEach((field) => field.addEventListener("input", calculate));
  courseList.append(row);
  calculate();
}

function calculate() {
  const rows = [...courseList.children];
  let credits = 0;
  let points = 0;
  rows.forEach((row) => {
    const grade = row.querySelector("select").value;
    const creditValue = Number(row.querySelectorAll("input")[1].value) || 0;
    credits += creditValue;
    points += gradePoints[grade] * creditValue;
  });
  const gpa = credits ? points / credits : 0;
  courseCount.textContent = `${rows.length} course${rows.length === 1 ? "" : "s"}`;
  score.textContent = gpa.toFixed(2);
  scoreFill.style.width = `${Math.min(gpa / 4 * 100, 100)}%`;
  totalCredits.textContent = credits % 1 ? credits.toFixed(1) : credits;
  qualityPoints.textContent = points.toFixed(2);
  resultCopy.textContent = !rows.length ? "Add your courses to see your GPA." : gpa >= 3.5 ? "Excellent work. Keep that momentum going." : gpa >= 2.5 ? "A solid foundation with room to grow." : "Every semester is a fresh opportunity.";
}

document.querySelector("#add-course").addEventListener("click", () => addCourse());
document.querySelector("#clear-courses").addEventListener("click", () => { courseList.replaceChildren(); calculate(); });
addCourse("Course 01", "A", "3");
addCourse("Course 02", "B", "3");
addCourse("Course 03", "A", "4");