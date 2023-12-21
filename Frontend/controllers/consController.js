async function addCons(event) {
  event.preventDefault();
  const form = event.target;
  const { idConclusion, date, information, reception, diseaseHistory } =
    form.elements;
  await insertCons(
    idConclusion.value,
    date.value,
    information.value,
    reception.value,
    diseaseHistory.value
  );

  location.reload();
}

async function removeCons(event) {
  event.preventDefault();
  const form = event.target;
  const { idConclusion } = form.elements;
  await deleteCons(idConclusion.value);
  location.reload();
}

document.querySelector("#add-cons-form").addEventListener("submit", addCons);
document
  .getElementById("delete-cons-form")
  .addEventListener("submit", removeCons);
