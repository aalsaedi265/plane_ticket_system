
from django.shortcuts import render, redirect
from django.views import View
from django.conf import settings
from django.contrib import messages
import requests
import requests

class BookingListView(View):
    def get(self, request):
        # Initialize an empty list for our flights data
        flights = []
        error_message = None
        
        try:
            # Make request to C# backend API
            response = requests.get(f"{settings.API_BASE_URL}/schedules")
            
            if response.status_code == 200:
                flights = response.json()
                print("Successfully fetched flights:", flights)  # Debug print
            else:
                error_message = f"Server returned status code: {response.status_code}"
                print(f"API request failed: {error_message}")
                print(f"Response content: {response.text}")
                
        except requests.RequestException as e:
            error_message = "Unable to connect to flight service"
        
        # Pass both flights and error_message to the template
        return render(request, 'list.html', {
            'flights': flights,
            'error_message': error_message
        })

    def post(self, request):
        try:
            booking_data = {
                'flightNumber': request.POST.get('flightNumber'),
                'passengerName': request.POST.get('passengerName'),
                'status': 'Confirmed'
            }

            response = requests.post(
                f"{settings.API_BASE_URL}/booking",
                json=booking_data
            )

            if response.status_code in [200, 201]:
                messages.success(request, 'Flight booked successfully!')
            else:
                messages.error(request, 'Failed to book flight. Please try again.')

        except requests.RequestException as e:
            messages.error(request, f'Connection error: {str(e)}')

        return redirect('booking:home')