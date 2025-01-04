

from django.shortcuts import render
from django.views import View
from django.conf import settings
import os

class BookingListView(View):
    def get(self, request):
        # Debug print to see where Django is looking for templates
        template_dirs = settings.TEMPLATES[0]['DIRS']
        print(f"Looking for templates in: {template_dirs}")
        print(f"Project BASE_DIR is: {settings.BASE_DIR}")
        print(f"Template should be in: {os.path.join(settings.BASE_DIR, 'templates', 'list.html')}")
        return render(request, 'list.html')