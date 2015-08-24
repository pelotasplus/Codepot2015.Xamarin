from django.contrib.auth.models import User
from rest_framework import serializers
from main.models import Item, Category

class BaseSerializer(serializers.ModelSerializer):
    def from_native(self, data, files=None):
        obj = super(BaseSerializer, self).from_native(data, files)
        print '>>>>', data
        if obj is None:
            return obj
        if data and 'owner' in data:
            print obj, data
            obj.owner = data['owner']
        return obj


class UserSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = User
        fields = ('id', 'username', 'email', 'is_staff')


class CategorySerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Category
        fields = ('id', 'name', 'image')


class ItemSerializer(BaseSerializer):
    category = serializers.PrimaryKeyRelatedField(queryset=Category.objects.all())

    class Meta:
        model = Item
        fields = ('id', 'name', 'done', 'category', 'owner')