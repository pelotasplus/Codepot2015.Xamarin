from django.contrib.auth.models import User
from django.db import models


class Category(models.Model):
    name = models.CharField(max_length=256)
    image = models.CharField(max_length=256)

    def __unicode__(self):
        return unicode(self.name)

class Item(models.Model):
    name = models.CharField(max_length=256)
    created = models.DateTimeField(auto_now_add=True)
    done = models.BooleanField(default=False)
    category = models.ForeignKey(Category, null=True, blank=True)
    owner = models.ForeignKey(User, null=True, blank=True)

    # @property
    # def category_id(self):
    #     return self.category.id
