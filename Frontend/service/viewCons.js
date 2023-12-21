async function getCons() {
  const response = await fetch("http://localhost:5002/api/ViewInformation", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}
async function getConsSearch(filter) {
  const response = await fetch(
    "http://localhost:5002/api/ViewInformation?" + new URLSearchParams(filter),
    {
      method: "GET",
    }
  );
  const result = await response.json();
  return result;
}

function setupCheckboxHandlers() {
  const checkboxes = document.querySelectorAll("input[type='text']");
  checkboxes.forEach((cb) => {
    cb.onchange = checkboxOnchange;
  });
}

function checkboxOnchange(event) {
  const filterName = event.target.name;
  const checboxId = event.target.id;

  const checkboxes = document.querySelectorAll(
    `input[type='text'][name='${filterName}']`
  );
  checkboxes.forEach((cb) => {
    if (cb.id !== checboxId) {
      cb.checked = false;
    }
  });
}

function setupFormSubmit() {
  const form = document.querySelector("#filter");
  form.onsubmit = async function (event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const filter = Object.fromEntries(formData);

    // const result = await getViewSpa(filter);
    displayView(filter);
    // console.log(filter, result);
  };
}
setupCheckboxHandlers();
setupFormSubmit();
