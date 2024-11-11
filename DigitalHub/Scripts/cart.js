function updateQuantity(productId, quantity) {
    if (typeof quantity !== 'number') {
        quantity = parseInt(quantity);
    }

    // Nếu người dùng nhấn nút + hoặc -
    if (quantity === 1 || quantity === -1) {
        const input = document.querySelector(`input[data-product-id="${productId}"]`);
        const currentQuantity = parseInt(input.value);
        quantity = currentQuantity + quantity;

        if (quantity < 1) quantity = 1;
    }

    $.ajax({
        url: '/Cart/UpdateQuantity',
        type: 'POST',
        data: { productId, quantity },
        success: function (response) {
            if (response.success) {
                location.reload(); // Tải lại trang để cập nhật giỏ hàng
            }
        },
        error: function () {
            alert('Có lỗi xảy ra khi cập nhật số lượng');
        }
    });
}

function removeFromCart(productId) {
    if (confirm('Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng?')) {
        $.ajax({
            url: '/Cart/RemoveFromCart',
            type: 'POST',
            data: { productId },
            success: function (response) {
                if (response.success) {
                    location.reload();
                }
            },
            error: function () {
                alert('Có lỗi xảy ra khi xóa sản phẩm');
            }
        });
    }
}

// Thêm vào giỏ hàng từ trang chi tiết sản phẩm
// cart.js


function addToCart(productId) {
    var quantity = $('#inputQuantity').val();
    $.ajax({
        url: '/Cart/AddToCart',
        type: 'POST',
        data: {
            productId: productId,
            quantity: quantity
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                alert('Sản phẩm đã được thêm vào giỏ hàng!');
            } else {
                alert('Có lỗi xảy ra: ' + response.message);
            }
        },
        error: function () {
            alert('Có lỗi xảy ra khi thêm sản phẩm vào giỏ hàng.');
        }
    });
}

// Các hàm khác như decreaseValue và increaseValue cũng nên được định nghĩa ở đây

function decreaseValue() {
    var quantityInput = $('#inputQuantity');
    var currentValue = parseInt(quantityInput.val());
    if (currentValue > 1) {
        quantityInput.val(currentValue - 1);
    }
}

function increaseValue() {
    var quantityInput = $('#inputQuantity');
    var currentValue = parseInt(quantityInput.val());
    quantityInput.val(currentValue + 1);
}

success: function (response) {
    console.log(response); // In ra response để kiểm tra
    if (response.success) {
        alert('Sản phẩm đã được thêm vào giỏ hàng!');
    } else {
        alert('Có lỗi xảy ra: ' + response.message);
    }
}