# 🌳 Binary Tree Serialize & Deserialize (C#)

Bu projede, bir ikili ağacın (binary tree) string olarak **serileştirilmesi** ve bu string'den tekrar **ağaç olarak oluşturulması** işlemleri iki farklı yöntemle gerçekleştirilmiştir:

---

## 🧭 1. Preorder (DFS – Derinlik Öncelikli Arama)

### ✔️ Yöntem Özeti
- Ağaç preorder olarak gezilir: **Kök → Sol → Sağ**
- `null` düğümler `"null"` şeklinde yazılır.
- Recursive (rekürsif) çözüm kullanılır.

### 🔧 Metotlar
- `string Serialize(TreeNode root)`
- `TreeNode Deserialize(string data)`

### 📌 Örnek

Verilen ağaç:
```
    1
   / \
  2   3
     / \
    4   5
```

**Serialized (preorder):**
```
"1,2,null,null,3,4,null,null,5,null,null"
```

---

## 🌐 2. Level-order (BFS – Genişlik Öncelikli Arama)

### ✔️ Yöntem Özeti
- Ağaç satır satır gezilir: **Seviye Seviye**
- Queue (kuyruk) veri yapısı kullanılır.
- `null` düğümler `"null"` olarak saklanır.

### 🔧 Metotlar
- `string Serialize(TreeNode root)`
- `TreeNode Deserialize(string data)`

### 📌 Örnek

Verilen ağaç:
```
    1
   / \
  2   3
     / \
    4   5
```

**Serialized (level-order):**
```
"1,2,3,null,null,4,5,null,null,null,null"
```

---

## 🔨 Kullanım

### Ağaç Oluşturma ve Test:

```csharp
var codec = new Codec();

TreeNode tree = new TreeNode(1,
    new TreeNode(2),
    new TreeNode(3, new TreeNode(4), new TreeNode(5))
);

string serialized = codec.Serialize(tree);
TreeNode deserialized = codec.Deserialize(serialized);
```

---

## 📁 Dosyalar

- `TreeNode.cs`: Ağacın düğüm sınıfı
- `Codec.cs`: Serialize ve Deserialize işlemleri
- `Program.cs`: Örnek kullanım

---

## 🧠 Notlar

- Preorder yöntemi **daha sade ve hafif** ağaçlar için önerilir.
- Level-order yöntemi **dengeli veya geniş ağaçlar** için daha net bir temsil sağlar.

---

## 👨‍💻 Geliştiren

- Coded by ChatGPT on behalf of Samet Paşa 👑
