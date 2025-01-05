
from django.shortcuts import render
from django.views import View
from django.conf import settings
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
            print(f"Error fetching flights: {str(e)}")
        
        # Pass both flights and error_message to the template
        return render(request, 'list.html', {
            'flights': flights,
            'error_message': error_message
        })