
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
            # Prepare the booking data
            booking_data = {
                'flightNumber': request.POST.get('flightNumber'),
                'passengerName': request.POST.get('passengerName'),
                'status': 'Confirmed'  # Initial status
            }
            
            print(f"Sending booking request: {booking_data}")
            
            headers = {
            'Content-Type': 'application/json'
            }

            # Send booking request to the C# backend
            response = requests.post(
                f"{settings.API_BASE_URL}/booking",
                json=booking_data,
                headers=headers
            )
            
            print(f"Response status: {response.status_code}")
            print(f"Response content: {response.text}")

            if response.status_code == 200 or response.status_code == 201:
                messages.success(request, 'Flight booked successfully!')
            else:
                messages.error(request, 'Failed to book flight. Please try again.')

        except requests.RequestException as e:
            messages.error(request, f'Error processing booking: {str(e)}')

        return redirect('/')  # Redirect back to the flight list