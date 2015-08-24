from django.contrib.auth.models import User
from rest_framework.authtoken.models import Token

from django.core.management.base import BaseCommand


class Command(BaseCommand):
    help = 'Closes the specified poll for voting'

    def handle(self, *args, **options):
        for user in User.objects.all():
            token = Token.objects.get_or_create(user=user)
            print "Token", token, "for", user
