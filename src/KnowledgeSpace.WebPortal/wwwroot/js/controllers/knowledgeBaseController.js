var knowledgeBaseController = function () {
    this.initialize = function () {
        var kbId = parseInt($('#hid_knowledge_base_id').val());
        loadComments(kbId);
        registerEvents();
    };

    function registerEvents() {
        $("#commentform").submit(function (e) {
            e.preventDefault(); // chặn submit mặc định
            var form = $(this);
            var url = form.attr('action');

            $.post(url, form.serialize()).done(function (response) {
                $("#txt_new_comment_content").val('');

                // 👉 Gọi lại toàn bộ comment từ API
                var kbId = parseInt($('#hid_knowledge_base_id').val());
                loadComments(kbId);

                // 👉 Cập nhật số lượng bình luận
                var numberOfComments = parseInt($('#hid_number_comments').val()) + 1;
                $('#hid_number_comments').val(numberOfComments);
                $('#comments-title').text('(' + numberOfComments + ') bình luận');
            });
        });
    }

    function loadComments(id) {
        $.get('/knowledgeBase/GetCommentByKnowledgeBaseId?knowledgeBaseId=' + id).done(function (response, statusText, xhr) {
            if (xhr.status === 200) {
                var template = $('#tmpl_comments').html();
                var childrenTemplate = $('#tmpl_children_comments').html();
                if (response) {
                    var html = '';
                    $.each(response, function (index, item) {
                        var childrenHtml = '';
                        if (item.children.length > 0) {
                            $.each(item.children, function (childIndex, childItem) {
                                childrenHtml += Mustache.render(childrenTemplate, {
                                    content: childItem.content,
                                    createDate: childItem.createDate,
                                    ownerName: childItem.ownerName
                                });
                            });
                        }
                        html += Mustache.render(template, {
                            childrenHtml: childrenHtml,
                            content: item.content,
                            createDate: item.createDate,
                            ownerName: item.ownerName
                        });
                    });
                    $('#comment_list').html(html);
                }
            }
        });
    }
};
