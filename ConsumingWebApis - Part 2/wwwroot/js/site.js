// New Addition
async function fetchHolidays() {
    // Grabbing the values from the input fields
    const countryCode = document.getElementById("countryCode").value;
    const year = document.getElementById("year").value;
    const resultsContainer = document.getElementById("results");
    const table = document.getElementById("holidays-table");
    const tableBody = document.getElementById("holidays-table-body");

    table.style.display = 'none'; // Hides table initially
    tableBody.innerHTML = ''; // Clears previous table rows

    // Making sure both countryCode and year are entered by the user
    if (!countryCode || !year) {
        resultsContainer.innerHTML = "<p>Please provide both country code and year.</p>";
        return;
    }

    // Fetching outputs from the entered countryCode and year
    try {
        // Fetches the holidays from the API
        const response = await fetch(`/api/home?countryCode=${countryCode}&year=${year}`);
        if (!response.ok) {
            throw new Error(`Error: ${response.status} ${response.statusText}`);
        }
        const holidays = await response.json();

        // Tell the user if no holidays were found
        if (holidays.length === 0) {
            resultsContainer.innerHTML = "<p>No holidays found.</p>";
            return;
        }

        // Populates table with fetched holiday data
        holidays.forEach(holiday => {
            const row = document.createElement("tr");

            // Formats the date to mm/dd/yyyy if it exists
            // Converting the date string to a Date object if found
            const date = holiday.date ? new Date(holiday.date) : null;
            // Rearranging the date to mm/dd/yyyy format
            const formattedDate = date ? `${String(date.getMonth() + 1).padStart(2, '0')}/
            ${String(date.getDate()).padStart(2, '0')}/
            ${date.getFullYear()}` : "N/A";

            // Fills up the information grabbed from the API in a row
            row.innerHTML = `
                <td>${formattedDate}</td>
                <td>${holiday.name}</td>
                <td>${holiday.localName}</td>
                <td>${holiday.countryCode}</td>
                <td>${holiday.global ? "Yes" : "No"}</td>
            `;
            // Appends the row to the table
            tableBody.appendChild(row);
        });

        // Shows table after data is added
        table.style.display = 'table';
    } catch (error) {
        // Displays error message if there was an error
        resultsContainer.innerHTML = `<p>${error.message}</p>`;
    }
}
