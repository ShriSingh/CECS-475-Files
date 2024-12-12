const uri = 'api/todoitems';
let todos = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

// New Addition
function dateFormatting(dateEntered) {
    // Separating year, month, and day at the dashes('-')
    const [year, month, day] = dateEntered.split('-');
    // Return the date in the US-format
    return `${month}/${day}/${year}`;
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');
    // New Addition
    const addCompletionDate = document.getElementById('add-completion-date');

    const item = {
        isComplete: false,
        name: addNameTextbox.value.trim(),
        completionDate: addCompletionDate.value     // New Addition
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
            addCompletionDate.value = '';           // New Addition
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = todos.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isComplete;
    // New Addition
    document.getElementById('edit-completion-date').value = item.completionDate;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    // New Addition
    const addCompletionDate = document.getElementById('edit-completion-date').value;

    const item = {
        id: parseInt(itemId, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim(),
        // New Addition
        completionDate: addCompletionDate
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = false;
        isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);

        // New Addition
        let td2 = tr.insertCell(1);
        // let formattedDate = item.completionDate ? item.completionDate : '/';
        let formattedDate = dateFormatting(item.completionDate);
        let textNode_1 = document.createTextNode(formattedDate);
        td2.appendChild(textNode_1);

        let td3 = tr.insertCell(2);
        let textNode_2 = document.createTextNode(item.name);
        td3.appendChild(textNode_2);

        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        // let td5 = tr.insertCell(4);
        td4.appendChild(deleteButton);
    });

    todos = data;
}