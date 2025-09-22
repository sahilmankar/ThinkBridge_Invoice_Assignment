
document.addEventListener('DOMContentLoaded', function() {
    fetch('/api/invoice')
        .then(resp => resp.json())
        .then(data => {
            let html = '<ul>';
            data.forEach(invoice => {
                html += `<h3>Invoice #${invoice.invoiceID} - ${invoice.customerName}</h3>`;
                html += '<ul>';
                invoice.items.forEach(item => {
                    html += `<li>${item.itemName} - $${item.itemPrice.toFixed(2)}</li>`;
                });
                html += '</ul>';
            });

            document.getElementById('invoice-container').innerHTML = html;
        })
        .catch(er => console.eror("Failed to load invoice:", er));
});
