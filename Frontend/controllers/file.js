// Sample array of objects
const data = document.getElementById("element");

// Function to filter the data based on multiple parameters
function filterData(data, filters) {
  return data.filter((item) => {
    // Iterate over each filter
    for (const key in filters) {
      if (filters.hasOwnProperty(key)) {
        // Check if the object has the current filter property
        if (item.hasOwnProperty(key)) {
          // Check if the property value matches the filter value
          if (item[key] !== filters[key]) {
            // Return false if any filter condition fails
            return false;
          }
        } else {
          // Return false if the object doesn't have the filter property
          return false;
        }
      }
    }
    // Return true if all filter conditions pass
    return true;
  });
}

// Apply the filters
const filteredData = filterData(data, filters);

// Output the filtered data
console.log(filteredData);
