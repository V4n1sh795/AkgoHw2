import sys

class SegmentTree:
    def __init__(self, n):
        self.n = n
        self.tree = [0] * (4 * n)

    def update(self, idx, val, node=1, left=1, right=None):
        if right is None:
            right = self.n
        if left == right:
            self.tree[node] = val
            return
        mid = (left + right) // 2
        if idx <= mid:
            self.update(idx, val, node * 2, left, mid)
        else:
            self.update(idx, val, node * 2 + 1, mid + 1, right)
        self.tree[node] = self.tree[node * 2] + self.tree[node * 2 + 1]

    def query(self, ql, qr, node=1, left=1, right=None):
        if right is None:
            right = self.n
        if ql > right or qr < left:
            return 0
        if ql <= left and right <= qr:
            return self.tree[node]
        mid = (left + right) // 2
        return self.query(ql, qr, node * 2, left, mid) + \
               self.query(ql, qr, node * 2 + 1, mid + 1, right)


def main():
    input_data = sys.stdin.read().strip().split()
    if not input_data:
        return
    it = iter(input_data)
    n = int(next(it))
    k = int(next(it))

    seg = SegmentTree(n)

    out_lines = []
    for _ in range(k):
        typ = next(it)
        if typ == 'A':
            i = int(next(it))
            x = int(next(it))
            seg.update(i, x)
        elif typ == 'Q':
            l = int(next(it))
            r = int(next(it))
            out_lines.append(str(seg.query(l, r)))

    sys.stdout.write("\n".join(out_lines))


if __name__ == "__main__":
    main()