
from django.shortcuts import render, redirect
from django.contrib.auth import authenticate, login, logout
from django.http import JsonResponse
import requests
import json

class AuthenticationService:
    API_BASE_URL = 'http://localhost:5257/api'
    
    @staticmethod
    def register_user(request):
        if request.method == 'POST':
            data = {
                'username': request.POST.get('username'),
                'email': request.POST.get('email'),
                'password': request.POST.get('password'),
                'fullName': request.POST.get('full_name'),
                'phoneNumber': request.POST.get('phone_number')
            }
            
            response = requests.post(
                f'{AuthenticationService.API_BASE_URL}/users/register',
                json=data
            )
            
            if response.status_code == 201:
                return JsonResponse({'status': 'success'})
            return JsonResponse({'status': 'error', 'message': response.json().get('message')})
            
    @staticmethod
    def login_user(request):
        if request.method == 'POST':
            data = {
                'username': request.POST.get('username'),
                'password': request.POST.get('password')
            }
            
            response = requests.post(
                f'{AuthenticationService.API_BASE_URL}/users/login',
                json=data
            )
            
            if response.status_code == 200:
                token_data = response.json()
                # Store JWT token in session
                request.session['auth_token'] = token_data.get('token')
                return JsonResponse({'status': 'success'})
            return JsonResponse({'status': 'error', 'message': 'Invalid credentials'})