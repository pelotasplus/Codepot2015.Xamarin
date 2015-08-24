from django.contrib.auth.models import User
from rest_framework import viewsets
from rest_framework import permissions
from main.models import Category, Item
from main.serializers import UserSerializer, CategorySerializer, ItemSerializer


class BaseViewSet(viewsets.ModelViewSet):
    ordering_fields = '__all__'
    
    def get_queryset(self):
        return self.model.objects.filter(owner=self.request.user)

    def create(self, request):
        print request.user.id
        request.data['owner'] = request.user.id
        return super(BaseViewSet, self).create(request)

    def update(self, request, *args, **kwargs):
        request.data['owner'] = request.user.id
        return super(BaseViewSet, self).update(request, *args, **kwargs)

    def partial_update(self, request, *args, **kwargs):
        request.data['owner'] = request.user.id
        return super(BaseViewSet, self).partial_update(request, *args, **kwargs)

class UserViewSet(viewsets.ModelViewSet):
    queryset = User.objects.all()
    serializer_class = UserSerializer
    permission_classes = (permissions.IsAdminUser,)

class ItemViewSet(BaseViewSet):
    model = Item
    queryset = Item.objects.all()
    serializer_class = ItemSerializer
    permission_classes = (permissions.IsAuthenticated,)

class CategoryViewSet(viewsets.ReadOnlyModelViewSet):
    queryset = Category.objects.all()
    serializer_class = CategorySerializer
    permission_classes = (permissions.IsAuthenticated,)
