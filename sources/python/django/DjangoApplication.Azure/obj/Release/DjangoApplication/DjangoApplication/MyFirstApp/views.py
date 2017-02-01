# Create your views here.
from django.http import HttpResponse
from django.template.loader import render_to_string
def home(request):
    return HttpResponse(render_to_string(
                                          'index.html',
                                          {
                                           'content': 'Hello World', 
                                           'title': 'Teste Hello World'
                                          }
                                         ))