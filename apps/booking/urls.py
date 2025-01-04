
from django.urls import path
from . import views

app_name = 'booking'

urlpatterns = [
    path('bookings/', views.BookingListView.as_view(), name='booking_list'),
    path('', views.BookingListView.as_view(), name='home'),
]