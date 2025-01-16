

class BookingModal {
    constructor() {
        this.modal = document.getElementById('bookingModal');
        this.form = document.getElementById('bookingForm');
        this.flightNumberInput = document.getElementById('flightNumber');
        
        this.initializeEventListeners();
    }

    initializeEventListeners() {
        // Close modal when clicking outside
        this.modal.addEventListener('click', (e) => {
            if (e.target === this.modal) {
                this.close();
            }
        });
    }

    open(flightNumber) {
        this.flightNumberInput.value = flightNumber;
        this.modal.classList.remove('hidden');
    }

    close() {
        this.modal.classList.add('hidden');
        this.form.reset();
    }
}

// Initialize booking modal when document loads
document.addEventListener('DOMContentLoaded', () => {
    window.bookingModal = new BookingModal();
});